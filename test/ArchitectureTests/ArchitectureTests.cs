using System.Reflection;
using FluentAssertions;
using NetArchTest.Rules;

namespace ArchitectureTests;

public class ArchitectureTests
{    
    private const string ApplicationNamespace = "Application";
    private const string PresentationNamespace = "Presentation";
    private const string InfrastructureNamespace = "Infrastructure";
    private const string ApiNamespace = "API";

    private static Assembly DomainAssembly =>
        typeof(Domain.DependencyInjection).Assembly;

    private static Assembly ApplicationAssembly =>
        typeof(Application.DependencyInjection).Assembly;

    private static Assembly PresentationAssembly =>
        typeof(Presentation.DependencyInjection).Assembly;

    private static Assembly InfrastructureAssembly =>
        typeof(Infrastructure.DependencyInjection).Assembly;
    
    [Fact(DisplayName = "Domain should not have dependency on other projects")]
    public void Domain_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = DomainAssembly;

        string[] otherProjects =
        [
            ApplicationNamespace,
            InfrastructureNamespace,
            PresentationNamespace,
            ApiNamespace
        ];
        
        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();
        
        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact(DisplayName = "Application should not have dependency on other projects")]
    public void Application_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = ApplicationAssembly;

        string[] otherProjects =
        [
            InfrastructureNamespace,
            PresentationNamespace,
            ApiNamespace
        ];
        
        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();
        
        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }
    
    
    [Fact(DisplayName = "Infrastructure should not have dependency on other projects")]
    public void Infrastructure_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = InfrastructureAssembly;

        string[] otherProjects =
        [
            PresentationNamespace,
            ApiNamespace
        ];
        
        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();
        
        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact(DisplayName = "Presentation should not have dependency on other projects")]
    public void Presentation_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = PresentationAssembly;

        string[] otherProjects =
        [
            InfrastructureNamespace,
            ApiNamespace
        ];
        
        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();
        
        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }
}